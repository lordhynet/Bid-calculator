import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BidCalculationService } from '../../services/bid-calculation.service';
import { VehicleType } from '../../models/vehicle-type.enum';
import { Fees } from '../../models/fees.model';
import { enumToArray } from 'src/app/utils/enum.utils';
import { getDefaultApiResponse, IApiPayload, IApiResponse } from 'src/app/models/apis.model';
import { debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-bid-calculator',
  templateUrl: './bid-calculator.component.html',
  styleUrls: ['./bid-calculator.component.scss']
})
export class BidCalculatorComponent implements OnInit {
  bidForm: FormGroup;
  totalCost: number = 0;
  fees: IApiResponse = getDefaultApiResponse();
  VehicleType = VehicleType;
  vehicleTypes = enumToArray(VehicleType);


  constructor(private fb: FormBuilder, private bidCalcService: BidCalculationService) {
    this.bidForm = this.fb.group({
      basePrice: [0],
      type: [VehicleType.Common]
    });
  }


  ngOnInit(): void {
    this.loadData();

    this.bidForm.valueChanges.pipe(
      debounceTime(500),
      distinctUntilChanged((prev, curr) => JSON.stringify(prev) === JSON.stringify(curr))
    ).subscribe(values => {
      this.loadData();
    });
  }


  loadData(): void {
    const { basePrice, type } = this.bidForm.value;

    if (basePrice === null || basePrice === undefined || basePrice <= 0) {
      this.fees = getDefaultApiResponse();
      if (basePrice === null || basePrice === undefined) {
        window.alert('Enter a valid base price');
      }
      return;
    }

    const payload: IApiPayload = { basePrice, type: Number(type) };
    this.bidCalcService.fetchData(payload).subscribe({
      next: data => {
        this.fees = data;
      },
      error: error => {
        console.error('Error:', error); // For logging
        window.alert(error.message || 'Enter a correct value');
      }
    });
  }

  
}
