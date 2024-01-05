import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Movie } from '../movie';
import { MovieService } from '../movie.service';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {
   movies:Movie[]=[];
   formattedReleaseDates!: string[];
   constructor(public movieService:MovieService) {  }

   formatDate(date: Date): string {
    // Get date components
    const dt = new Date(date);
    const year = dt.getFullYear();
    const month = (dt.getMonth() + 1).toString().padStart(2, '0');
    const day = dt.getDate().toString().padStart(2, '0');
    //console.log(year,month,day);
    // Concatenate and return formatted date
    return `${year}-${month}-${day}`;

  }


    ngOnInit():void{
      this.movieService.getAll().subscribe((data)=>{
        this.movies = data.data;
        this.formattedReleaseDates = this.movies.map(movie => this.formatDate(movie.releaseDate));
        console.log(this.movies);
        
      })
    }

    deleteMovie(id:number){
      this.movieService.delete(id).subscribe(res => {
        this.movies = this.movies.filter(item => item.id !== id);
        alert("Are you sure?");
      })
    }

    openTrailer(trailerUrl: string): void {
      // Open the trailer URL in a new tab/window
      window.open(trailerUrl, '_blank');
    }
  
 
}


