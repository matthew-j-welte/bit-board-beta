import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Skill } from '../+models/dtos/skill_dto';

@Component({
  selector: 'app-mentor-page',
  templateUrl: './mentor-page.component.html',
  styleUrls: ['./mentor-page.component.css'],
})
export class MentorPageComponent implements OnInit {
  modalRef: BsModalRef;
  skills: Skill[];

  constructor(private modalService: BsModalService) {}

  ngOnInit(): void {}

  openModalWithClass(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(
      template,
      Object.assign({}, { class: 'gray modal-lg' })
    );
  }
}
