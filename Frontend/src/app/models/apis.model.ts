import { VehicleType } from "./vehicle-type.enum";

export interface IApiResponse {
  basePrice: number;
  basicFee: number,
  specialFee: number,
  associationFee: number,
  storageFee: number,
  totalCost: number
}

export interface IApiPayload {
    basePrice: number;
    type: VehicleType;
}

export function getDefaultApiResponse(): IApiResponse {
    return {
      basePrice: 0,
      basicFee: 0,
      specialFee: 0,
      associationFee: 0,
      storageFee: 0,
      totalCost: 0
    };
  }