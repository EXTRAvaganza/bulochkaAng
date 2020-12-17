using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bulochka.Entities;
using Microsoft.EntityFrameworkCore;

namespace bulochka.Services
{
    public class BulochkaService
    {
        private readonly ApplicationContext context;

        public BulochkaService(ApplicationContext _context)
        {
            this.context = _context;
        }
        public IQueryable<Bulochka> GetAll()
        {
            return context.Bulochka.Select( t =>
                new Bulochka
                {
                    Id = t.Id,
                    ControlSellTime = t.ControlSellTime,
                    CreationTimestamp = t.CreationTimestamp,
                    DropTimestamp = t.DropTimestamp,
                    StartPrice = t.StartPrice,
                    Type = t.Type,
                    LastupdateTimestamp = t.LastupdateTimestamp,
                    CurrentPrice = t.CurrentPrice
                });
        }
        public  IQueryable<Bulochka> GetExpired()
        {
            return context.Bulochka.Where(x => x.DropTimestamp < DateTime.Now).Select(t =>
               new Bulochka
               {
                   Id = t.Id,
                   ControlSellTime = t.ControlSellTime,
                   CreationTimestamp = t.CreationTimestamp,
                   DropTimestamp = t.DropTimestamp,
                   StartPrice = t.StartPrice,
                   CurrentPrice = t.CurrentPrice,
                   Type = t.Type,
                   LastupdateTimestamp = t.LastupdateTimestamp
               });
        }
        public void DeleteExpired()
        {
            var list = context.Bulochka.Where(x => x.DropTimestamp.CompareTo(DateTime.Now)<0).ToList();
            foreach(var item in list)
            {
                context.Bulochka.Remove(item);
                context.SaveChanges();
            }
        }
        public void UpdateByControlTime()
        {
            var smetannik = context.Bulochka.Where(x =>
                x.Type.Id == 4 && // В моем случае ID сметанника == 4
                x.ControlSellTime.CompareTo(DateTime.Now)<=0 && 
                DateTime.Now.Subtract(x.LastupdateTimestamp).TotalHours > 1.0).Select(x => x).ToList();
            foreach(var item in smetannik)
            {
                item.LastupdateTimestamp = DateTime.Now;
                item.CurrentPrice = item.CurrentPrice / 2.0f;
                context.Bulochka.Update(item);
            }
            var krendel = context.Bulochka.Where(x =>
                x.Type.Id == 2 && // В моем случае ID кренделя == 4
                x.ControlSellTime.CompareTo(DateTime.Now) <= 0 &&
                x.LastupdateTimestamp.CompareTo(x.ControlSellTime)<0).Select(x => x).ToList();
            foreach (var item in krendel)
            {
                item.LastupdateTimestamp = DateTime.Now;
                item.CurrentPrice = item.CurrentPrice * 0.96f;
                context.Bulochka.Update(item);
            }
            
            var others = context.Bulochka.Where(x => 
            x.Type.Id != 2 &&
            x.Type.Id != 4 &&
            x.ControlSellTime.CompareTo(DateTime.Now) <= 0 &&
            DateTime.Now.Subtract(x.LastupdateTimestamp).TotalHours > 1.0).Select(x => x).ToList();
            foreach(var item in others)
            {
                item.CurrentPrice = item.CurrentPrice * 0.98f;
                item.LastupdateTimestamp = DateTime.Now;
            }
            context.SaveChanges();
        }
        public void Update(Bulochka bulochka)
        {
            bulochka.LastupdateTimestamp = DateTime.Now;
            context.Bulochka.Update(bulochka);
            context.SaveChanges();   
        }
        public async void Insert(Bulochka bulochka)
        {
            context.Bulochka.Add(bulochka);
            await context.SaveChangesAsync();
        }
    }
}

