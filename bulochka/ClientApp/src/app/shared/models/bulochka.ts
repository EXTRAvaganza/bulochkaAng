import { BulochkaTypes } from "./bulochkaTypes";

export interface IBulochka {
    id: number;
    creationTimestamp: string;
    lastupdateTimestamp: string;
    dropTimestamp: string;
    startPrice: number;
    currentPrice: number;
    controlSellTime: string;
    type: BulochkaTypes;
} 