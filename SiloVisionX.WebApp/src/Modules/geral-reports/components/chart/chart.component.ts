import { Component } from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { GeralInnerService } from '../../service/geral-inner.service';
import { Subject, takeUntil } from 'rxjs';

Chart.register(...registerables);

@Component({
  selector: 'chart',
  standalone: false,
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent {

  constructor(private pageService: GeralInnerService) {}

  chart!: Chart;
  filter: 'max' | 'min' = 'max';
  data: any[] = [];

  private lifeCyle = new Subject<void>();

  ngOnInit(): void {
    this.registerChartData();
  }

  ngOnDestroy(): void {
    this.lifeCyle.next();
    this.lifeCyle.complete();
  }

  private registerChartData() {
    this.pageService.$apiData
      .pipe(takeUntil(this.lifeCyle))
      .subscribe({
        next: (state: any) => {
          this.data = state.data.map((item: any) => ({
            rawDate: item.data,
            dateFormatted: this.formatarDataBr(item.data), 
            dateOnly: this.formatarDataBrSimples(item.data), 
            temperature: item.temperaturaValue,
            humidity: item.umidadeValue,
            level: item.nivelValue
          }));
          this.createChart();
        }
      });
  }

  private createChart() {
  const ctx = (document.getElementById('barChart') as HTMLCanvasElement)?.getContext('2d');
  if (!ctx) return;

  if (this.chart) {
    this.chart.destroy();
  }

  
  const groupedData = this.agruparPorDia(this.data, this.filter);

  const labels = groupedData.map(g => g.dateOnly);
  const temps = groupedData.map(g => g.temperature);
  const hums = groupedData.map(g => g.humidity);
  const levels = groupedData.map(g => g.level);

  const allValues = [...temps, ...hums, ...levels];
  const maxVal = Math.max(...allValues);
  const minVal = Math.min(...allValues);
  const padding = Math.max(10, (maxVal - minVal) * 0.1);

  const yMax = maxVal + padding;
  const yMin = Math.min(0, minVal - padding);

  this.chart = new Chart(ctx, {
    type: 'bar',
    data: {
      labels: labels,
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
          beginAtZero: false,
          min: yMin,
          max: yMax
        }
      }
    }
  });
}


  onFilterChange(value: 'max' | 'min') {
    this.filter = value;
    this.createChart();
  }

  private agruparPorDia(data: any[], filter: 'max' | 'min') {
    
    const map = new Map<string, any>();

    data.forEach(item => {
      const key = item.dateOnly;

      if (!map.has(key)) {
        map.set(key, item);
      } else {
        const current = map.get(key);

        
        const currentSum = current.temperature + current.humidity + current.level;
        const itemSum = item.temperature + item.humidity + item.level;

        if (filter === 'max' && itemSum > currentSum) {
          map.set(key, item);
        } else if (filter === 'min' && itemSum < currentSum) {
          map.set(key, item);
        }
      }
    });

    return Array.from(map.values());
  }

  private formatarDataBr(data?: string | Date | null): string {
    if (!data) {
      return '01/01/0001 01:01';
    }

    const d = new Date(data);
    const dia = String(d.getDate()).padStart(2, '0');
    const mes = String(d.getMonth() + 1).padStart(2, '0');
    const ano = d.getFullYear();
    const horas = String(d.getHours()).padStart(2, '0');
    const minutos = String(d.getMinutes()).padStart(2, '0');

    return `${dia}/${mes}/${ano} ${horas}:${minutos}`;
  }

  private formatarDataBrSimples(data?: string | Date | null): string {
    if (!data) {
      return '01/01/0001';
    }

    const d = new Date(data);
    const dia = String(d.getDate()).padStart(2, '0');
    const mes = String(d.getMonth() + 1).padStart(2, '0');
    const ano = d.getFullYear();

    return `${dia}/${mes}/${ano}`;
  }

}
