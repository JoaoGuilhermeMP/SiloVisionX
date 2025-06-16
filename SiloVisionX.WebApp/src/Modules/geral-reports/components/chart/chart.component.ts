import { Component } from '@angular/core';
import { Chart, ChartConfiguration, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'chart',
  standalone: false,
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent {


  chart!: Chart;
  filter: 'max' | 'min' = 'max';

  
  data = [
    { day: '2025-06-10', temperature: 25, humidity: 70, level: 80 },
    { day: '2025-06-11', temperature: 28, humidity: 65, level: 75 },
    { day: '2025-06-12', temperature: 22, humidity: 60, level: 90 },
    { day: '2025-06-13', temperature: 30, humidity: 55, level: 85 },
    { day: '2025-06-14', temperature: 27, humidity: 68, level: 78 }
  ];

  ngAfterViewInit() {
    this.createChart();
  }

  createChart() {
    const ctx = (document.getElementById('barChart') as HTMLCanvasElement).getContext('2d');
    if (!ctx) return;

    if (this.chart) {
      this.chart.destroy();
    }

    
    const temps = this.data.map(d => d.temperature);
    const hums = this.data.map(d => d.humidity);
    const levels = this.data.map(d => d.level);

    const maxValue = this.filter === 'max'
      ? Math.max(...temps, ...hums, ...levels)
      : Math.min(...temps, ...hums, ...levels);

    this.chart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: this.data.map(d => d.day),
        datasets: [
          {
            label: 'Temperatura',
            data: temps,
            backgroundColor: 'rgb(255, 255, 0)'
          },
          {
            label: 'Umidade',
            data: hums,
            backgroundColor: 'rgb(255, 165, 0)'
          },
          {
            label: 'Nível',
            data: levels,
            backgroundColor: 'rgb(255, 0, 0)'
          }
        ]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
            max: maxValue + 10 
          }
        }
      }
    });
  }

  onFilterChange(value: 'max' | 'min') {
    this.filter = value;
    this.createChart();
  }

}
