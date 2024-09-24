import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-targetgaincaloriemodal',
  templateUrl: './targetgaincaloriemodal.component.html',
  styleUrl: './targetgaincaloriemodal.component.css'
})
export class TargetgaincaloriemodalComponent {

  targetCalorieForm: FormGroup;
  showModal: boolean = false;

  constructor(private fb: FormBuilder, private router: Router) {
    this.targetCalorieForm = this.fb.group({
      targetCalories: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    const lastLoginDate = localStorage.getItem('dashgain');
    const today = new Date().toISOString().split('T')[0];
    if (lastLoginDate === "empty") {
      this.showModal = true;
      // localStorage.setItem('lastLoginDate', today);
    }
  }

  onSubmit(): void {
    if (this.targetCalorieForm.valid) {
      const targetCalories = this.targetCalorieForm.get('targetCalories')?.value;
      localStorage.setItem('targetgainCalories', targetCalories);
      this.showModal=false;
      this.closeModal();
    }
  }

  closeModal(): void {
    this.showModal = false;
    if (!this.targetCalorieForm.valid) {
      this.router.navigate(['home/features/cmp/cmphome']); // Redirect to the previous page if form is invalid
    }
  }

}
