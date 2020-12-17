import { IBulochka } from "./bulochka";
import { BulochkaTypes } from "./bulochkaTypes";

export class Bulochka implements IBulochka 
{
    id: number;
    creationTimestamp: string;
    lastupdateTimestamp: string;
    dropTimestamp: string;
    startPrice: number;
    currentPrice: number;
    controlSellTime: string;
    type: BulochkaTypes;
    futurePrice: number;
    secToChange: number;
}