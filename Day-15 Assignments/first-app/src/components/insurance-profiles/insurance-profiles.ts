import { Component } from '@angular/core';

@Component({
  selector: 'app-insurance-profiles',
  imports: [],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
   selectedType: string | null = null;

  selectCard(type: string) {
    this.selectedType = type;
  }
}
