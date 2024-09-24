import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { AuthService } from '../../../../services/auth.service';
import { Updateuser } from '../../models/Updateuser';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  updateUserForm: FormGroup;

  constructor(private authservice:AuthService,private fb:FormBuilder,private modalService:NgbModal,private cd: ChangeDetectorRef){
    this.updateUserForm = this.fb.group({
      FullName: [''],
      UserName: [''],
      Email: ['',  Validators.email],
      Password: [''],
      Gender: [''],
      Age: ['']
    });

  }


  username!:string;
  id!:string;
 

  ngOnInit():void{
    const claims = this.authservice.getClaims();
    if (claims) {
      
      this.username= claims.fullname; 
      this.id=claims.id;
      
    }

  }

  ngAfterViewInit():void{
    

  }

  logout():void{
    this.authservice.logout();
    Swal.fire({
      icon: 'success',
      title: `Visit Again!`,
      text: 'Successfully logged out!',
      timer: 3000,
      timerProgressBar: false,
      showConfirmButton: false,
      customClass: {
        confirmButton: 'custom-confirm-button'
      }
    });
  }

  Delete():void{
    this.authservice.deleteUser(this.id).subscribe({
      next:(data:any)=>{
        console.log(data);
      },
      error:(error)=>{
        console.log("error in",error);
      },
      complete:()=>{
        
        Swal.fire({
          icon: 'success',
          title: `Visit Again!`,
          text: 'Profile Deleted Successfully!',
          timer: 3000,
          timerProgressBar: false,
          showConfirmButton: false,
          customClass: {
            confirmButton: 'custom-confirm-button'
          }
        });
        
        console.log("User deleted successfully!");
        this.authservice.logout();
        setTimeout(() => {
          window.location.reload();
      }, 3000);
      }
    })
  }

  updateUserFormData:Updateuser={
    FullName:'',
    UserName:'',
    Email:'',
    Password:'',
    Gender:'',
    Age:null!
  }

  onSubmit(){
    this.updateUserFormData.FullName=this.updateUserForm.get("FullName")?.value||null;
    this.updateUserFormData.UserName=this.updateUserForm.get("UserName")?.value||null;
    this.updateUserFormData.Email=this.updateUserForm.get("Email")?.value||null;
    this.updateUserFormData.Age=this.updateUserForm.get("Age")?.value||null;
    this.updateUserFormData.Password=this.updateUserForm.get("Password")?.value||null;
    this.updateUserFormData.Gender=this.updateUserForm.get("Gender")?.value||null;

    this.authservice.updateUser(this.id,this.updateUserFormData).subscribe({
      next:(data:any)=>{
        console.log(data);
      },
      error:(error)=>{
        console.log("error in",error);
      },
      complete:()=>{
        
        console.log("user updated successfully!");
        Swal.fire({
          icon: 'success',
          title: `Profile updated!`,
          text: 'Please login again.',
          timer: 3000,
          timerProgressBar: false,
          showConfirmButton: false,
          customClass: {
            confirmButton: 'custom-confirm-button'
          }
        });
        // this.modalService.dismissAll();
        // this.cd.detectChanges();
        this.authservice.logout();

        setTimeout(() => {
          window.location.reload();
      }, 3000); // Adjust delay as needed
        
      }
    })
  }

  

}
