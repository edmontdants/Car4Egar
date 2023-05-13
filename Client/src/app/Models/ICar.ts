import { IOwner } from "./IOwner"
import { IRent } from "./IRent"

export interface ICar{
vin:string,
color:string,
rate:number,
ratedPeople:number,
mailage:string,
year:number,
available:boolean,
modelName:string,
locationOfRent:string,
costPerDay:number,
image:string,
insurance:boolean,
gearBoxType:string,
//isActivated:boolean,
ownerId:string,
ownerPic:string,
ownerName:string,
ownerPhone:string
}

