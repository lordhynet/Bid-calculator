import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BidCalculatorComponent } from './pages/bid-calculator/bid-calculator.component';

const routes: Routes = [
  { path: '', redirectTo: '/bid-calculator', pathMatch: 'full' },
  { path: 'bid-calculator', component: BidCalculatorComponent },
  { path: '**', redirectTo: '/bid-calculator' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
