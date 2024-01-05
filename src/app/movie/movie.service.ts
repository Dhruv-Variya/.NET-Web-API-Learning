import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Movie } from './movie';

@Injectable({
  providedIn: 'root'
})


export class MovieService {

  private API = 'http://localhost:5149/Movie';

  httpOptions ={
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
  }
  constructor(private httpClient:HttpClient) {}
  //get all metods
  getAll():Observable<any>{
   return this.httpClient.get(this.API+'/GetAll').pipe(catchError((error:HttpErrorResponse)=>{
     return throwError(error);
   }))
  }

  //create
  create(movie:Movie):Observable<any>{
   return this.httpClient.post(this.API,JSON.stringify(movie),this.httpOptions).pipe(catchError((error:HttpErrorResponse)=>{
     return throwError(error);
   }))
  }



  //find data get one

  find(id:number):Observable<any>{
   return this.httpClient.get(this.API+'/'+id).pipe(catchError((error:HttpErrorResponse)=>{
     return throwError(error);
   }))
  }

  //update
  update(id:number,movie:Movie):Observable<any>{
    movie.id = id;
   return this.httpClient.put(this.API,JSON.stringify(movie),this.httpOptions).pipe(catchError((error:HttpErrorResponse)=>{
     return throwError(error);
   }))
  }

  //delete
  delete(id:number){
   return this.httpClient.delete(this.API+'/'+id).pipe(catchError((error:HttpErrorResponse)=>{
     return throwError(error);
   }))
  }
}
