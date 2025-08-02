import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { NgZone } from '@angular/core';


interface Feature {
  title: string;
  description: string;
  image: string;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule, MatToolbarModule, MatButtonModule, MatCardModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(private ngZone: NgZone) {}

  features: Feature[] = [
    {
      title: 'Transactions',
      description: 'Easily record, edit, and categorize your income and expenses. Get real-time tracking of your daily cash flow.',
      image: 'assets/images/transaction.avif'
    },
    {
      title: 'Budgets',
      description: 'Create flexible budgets, track spending limits, and receive alerts when you approach your budget cap.',
      image: 'assets/images/budget.avif'
    },
    {
      title: 'Reports',
      description: 'Generate detailed monthly and yearly reports to analyze spending trends and optimize your savings goals.',
      image: './assets/images/reports.jpeg'
    },
    {
      title: 'Categories',
      description: 'Organize transactions into custom categories, making your expense tracking neat and insightful.',
      image: 'assets/images/categories.jpeg'
    }
  ];

  currentIndex = 0;

  ngOnInit() {
  this.ngZone.runOutsideAngular(() => {
    setInterval(() => {
      this.ngZone.run(() => {
        this.currentIndex = (this.currentIndex + 1) % this.features.length;
      });
    }, 3000);
  });
}
}
