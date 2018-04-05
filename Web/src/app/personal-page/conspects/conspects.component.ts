import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';

@Component({
  selector: 'app-conspects',
  templateUrl: './conspects.component.html',
  styleUrls: ['./conspects.component.scss'],
})
export class ConspectsComponent implements OnInit {

  conspectItems: ConspectItem[];  

  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {     
    this.conspectItems = await this.conspectsService.getConspects();
  }
}
