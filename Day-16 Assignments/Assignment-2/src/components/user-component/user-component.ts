import { Component } from '@angular/core';
import { User } from '../../app/interface/user';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-component',
  imports: [FormsModule],
  templateUrl: './user-component.html',
  styleUrl: './user-component.css',
})
export class UserComponent {
  users:User[]=[];
  user: User = { id: 0, name: '', email: '' };
  isEditMode=false;
  saveUser() {
    if (this.isEditMode) {
    const index = this.users.findIndex(u => u.id ===this.user.id);
    this.users[index] = { ...this.user };
    this.isEditMode = false;
    } 
    else { 
      this.user.id = Date.now(); // simple unique id
      this.users.push({ ...this.user });
      console.log(this.user);
    }
    this.resetForm();
  } 
  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }
 // DELETE
  deleteUser(id: number) {
    this.users = this.users.filter(u => u.id !== id);
  }
  resetForm() {
    this.user = { id: 0, name: '', email: '' };
  } 
}
