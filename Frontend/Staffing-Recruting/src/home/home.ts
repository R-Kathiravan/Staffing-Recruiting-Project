import { Component } from '@angular/core';
import { SharedModules } from '../Shared/shared-modules';
import { Header } from '../header/header';

@Component({
  selector: 'app-home',
  imports: [SharedModules, Header],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

}
