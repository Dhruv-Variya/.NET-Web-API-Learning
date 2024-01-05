import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Movie } from '../movie';
import { MovieService } from '../movie.service';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css'
})
export class ViewComponent {
  id!:number;
  movie!:Movie;
  formattedReleaseDate!: string;
  
  constructor(public movieService:MovieService, private router:Router, private route:ActivatedRoute){}

  formatDate(date: Date): string {
    // Get date components
    const dt = new Date(date);
    const year = dt.getFullYear();
    const month = (dt.getMonth() + 1).toString().padStart(2, '0');
    const day = dt.getDate().toString().padStart(2, '0');
    console.log(year,month,day);
    // Concatenate and return formatted date
    return `${year}-${month}-${day}`;

  }
  ngOnInit():void{
    this.id = this.route.snapshot.params['movieId'];
    this.movieService.find(this.id).subscribe((data:Movie) =>{
      this.movie = data.data;
      console.log(data.data.releaseDate);
      this.formattedReleaseDate = this.formatDate(data.data.releaseDate);
      
    })
  }
  
}
