import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  imports: [FormsModule],
  templateUrl: './add.component.html',
})
export class AddComponent {
  user = {
    name: '',
    age: 0,
    city: '',
    state: '',
    pincode: '',
  };

  constructor(
    private userService: UserService,
    private router: Router,
  ) {}

  submit() {
    this.userService.addUser(this.user).subscribe(() => {
      this.router.navigate(['/list']);
    });
  }
}
