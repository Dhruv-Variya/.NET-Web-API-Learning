import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MovieService } from '../movie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  form!:FormGroup;

  constructor(public movieService:MovieService , private router:Router) {
    
  }

  ngOnInit(){
    this.form = new FormGroup({
      title: new FormControl('',Validators.required),
      releaseDate: new FormControl('',Validators.required),
      genre: new FormControl('',Validators.required),
      cast: new FormControl('',Validators.required),
      lang: new FormControl('',Validators.required),
      rating: new FormControl('',Validators.required),
      treailerURL: new FormControl('',Validators.required)
    })
  }
  get f(){
    return this.form.controls;
  }

  submit(){
    console.log(this.form.value);
    this.movieService.create(this.form.value).subscribe((res:any)=>{
      alert("Post Created successfully!!!");
      this.router.navigateByUrl('movie/index');
    })
  }

}
