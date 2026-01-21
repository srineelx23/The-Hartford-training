import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private apiURL='http://localhost:3000/members'
  constructor(private http: HttpClient){}

  getMembers(){
    return this.http.get<Member[]>(this.apiURL)
  }

   addMember(member: any) {
    return this.http.post(this.apiURL, member);
  }

  updateMember(id: number, member: any) {
    return this.http.put(`${this.apiURL}/${id}`, member);
  }

  deleteMember(id: number) {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
export interface Member{
    id:number;
    name:string;
    email:string;
    active:boolean;
  }