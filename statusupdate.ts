import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-status-update',
  standalone: true,
  imports: [NgFor],
  templateUrl: './statusupdate.component.html',
  styleUrls: ['./statusupdate.component.css']
})
export class StatusUpdateComponent implements OnInit {
  items: any[] = [];
  totalAmount: number = 0;

  constructor(private router: Router) {}

  ngOnInit(): void {
  }
}
