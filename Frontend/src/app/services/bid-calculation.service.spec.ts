import { TestBed } from '@angular/core/testing';
import { BidCalculationService } from './bid-calculation.service';
import { VehicleType } from '../models/vehicle-type.enum';

describe('BidCalculationService', () => {
  let service: BidCalculationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BidCalculationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should calculate fees and total correctly for provided test cases', () => {
    const testCases = [
      { price: 398, type: VehicleType.Common, basic: 39.80, special: 7.96, association: 5, storage: 100, total: 550.76 },
      { price: 501, type: VehicleType.Common, basic: 50, special: 10.02, association: 10, storage: 100, total: 671.02 },
      { price: 57, type: VehicleType.Common, basic: 10, special: 1.14, association: 5, storage: 100, total: 173.14 },
      { price: 1800, type: VehicleType.Luxury, basic: 180, special: 72, association: 15, storage: 100, total: 2167 },
      { price: 1100, type: VehicleType.Common, basic: 50, special: 22, association: 15, storage: 100, total: 1287 },
      { price: 1000000, type: VehicleType.Luxury, basic: 200, special: 40000, association: 20, storage: 100, total: 1040320 },
    ];

    testCases.forEach(tc => {
      expect(service.calculateBasicFee(tc.price, tc.type)).toBeCloseTo(tc.basic, 2);
      expect(service.calculateSpecialFee(tc.price, tc.type)).toBeCloseTo(tc.special, 2);
      expect(service.calculateAssociationFee(tc.price)).toBe(tc.association);
      expect(service.calculateTotal(tc.price, tc.type)).toBeCloseTo(tc.total, 2);
    });
  });
});
