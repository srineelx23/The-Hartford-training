import { Component } from '@angular/core';
import { MemberService,Member } from '../../app/services/member-service';
import { inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Subject, switchMap, startWith } from 'rxjs';

@Component({
  selector: 'app-members-component',
  imports: [FormsModule,CommonModule],
  templateUrl: './members-component.html',
  styleUrl: './members-component.css',
})
export class MembersComponent {
  private memberService = inject(MemberService);

  private refresh$ = new Subject<void>();

  Members$ = this.refresh$.pipe(
    startWith(void 0),
    switchMap(() => this.memberService.getMembers())
  );


  member: Partial<Member> = {
    name: '',
    email: '',
    active: false
  };

  isEditMode = false;

 
  saveMember() {
    const request$ =
      this.isEditMode && this.member.id
        ? this.memberService.updateMember(this.member.id, this.member)
        : this.memberService.addMember(this.member);

    request$.subscribe(() => {
      this.resetForm();
      this.refresh$.next(); 
    });
  }

  
  editMember(m: Member) {
    this.member = { ...m };
    this.isEditMode = true;
  }

 
  deleteMember(id: number) {
    this.memberService.deleteMember(id).subscribe(() => {
      this.refresh$.next(); 
    });
  }

  resetForm() {
    this.member = { name: '', email: '', active: false };
    this.isEditMode = false;
  }
}
