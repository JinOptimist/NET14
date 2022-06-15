import { IUser } from './../../models/IUser';
import { Component, ViewChild, ElementRef, AfterViewInit, OnInit, Input, Output, EventEmitter} from '@angular/core';
import * as signalR from "@microsoft/signalr"

@Component({
  selector: 'app-canvas-drawing',
  templateUrl: './canvas-drawing.component.html',
  styleUrls: ['./canvas-drawing.component.scss']
})
export class CanvasDrawingComponent implements OnInit, AfterViewInit {
  
  @ViewChild('myCanvas')
  canvas!: ElementRef<HTMLCanvasElement>;  
  painting: boolean = false;

  private lineWidth: number = 3;
  private ctx: CanvasRenderingContext2D | undefined;

  constructor() { 
  }
  ngAfterViewInit(): void {
    this.ctx = this.canvas.nativeElement.getContext('2d') as CanvasRenderingContext2D;
    this.ctx.lineWidth = this.lineWidth;
  }
  

  ngOnInit(): void {
  }

  mouseDown(e : MouseEvent) : void{
    this.startPosition();
    this.ctx!.beginPath();
    console.log(`${e.offsetX} ${e.offsetY}`)
    this.ctx!.moveTo(e.offsetX, e.offsetY);
  }

  mouseUp() : void{
    this.finishedPosition();
  }

  draw(e : MouseEvent) : void{
    if(!this.painting){
      return;
    }

    console.log(`${e.offsetX} ${e.offsetY}`)
    this.ctx!.lineTo(e.offsetX, e.offsetY);
    this.ctx!.stroke();
  }

  startPosition() : void{
    this.painting = true;
  }

  finishedPosition() : void {
    this.painting = false;
    this.ctx?.closePath();
  }

  clearLine(){
    this.ctx?.clearRect(0,0,700, 500)
  }

}
