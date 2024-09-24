import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-targetcaloriemodal',
  templateUrl: './targetcaloriemodal.component.html',
  styleUrl: './targetcaloriemodal.component.css'
})
export class TargetcaloriemodalComponent {
  targetCalorieForm: FormGroup;
  showModal: boolean = false;

  constructor(private fb: FormBuilder, private router: Router) {
    this.targetCalorieForm = this.fb.group({
      targetCalories: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    const lastLoginDate = localStorage.getItem('dash');
    const today = new Date().toISOString().split('T')[0];
    if (lastLoginDate === "empty") {
      this.showModal = true;
      // localStorage.setItem('lastLoginDate', today);
    }
  }

  onSubmit(): void {
    if (this.targetCalorieForm.valid) {
      const targetCalories = this.targetCalorieForm.get('targetCalories')?.value;
      localStorage.setItem('targetCalories', targetCalories);
      this.showModal=false;
      this.closeModal();
    }
  }

  closeModal(): void {
    this.showModal = false;
    if (!this.targetCalorieForm.valid) {
      this.router.navigate(['home/features/exercise/exercisehome']); // Redirect to the previous page if form is invalid
    }
  }
}
