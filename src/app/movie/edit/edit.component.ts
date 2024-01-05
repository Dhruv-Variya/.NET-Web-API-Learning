import { Component } from '@angular/core';
import { Movie } from '../movie';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MovieService } from '../movie.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  id!:number;
  movie!:Movie;
  form!:FormGroup;
  
  
  constructor(public movieService:MovieService,private router:Router, private route:ActivatedRoute){}


  
  ngOnInit():void{
    this.id = this.route.snapshot.params['movieId'];
    this.movieService.find(this.id).subscribe((data:Movie)=>{
      this.movie=data.data;
      console.log(this.movie);
    })
    

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
    this.movieService.update(this.id,this.form.value).subscribe((res:any)=>{
      alert("Data Updated successfully!!!");
      this.router.navigateByUrl('movie/index');
    })
  }

}
