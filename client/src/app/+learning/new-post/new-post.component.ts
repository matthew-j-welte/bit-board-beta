import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserPostAction } from 'src/app/+learning/models';
import { FormConfig, FormFieldBuilder } from 'src/app/shared/helpers/form-helpers';
import { Post } from 'src/app/shared/models/dtos/post_dto';
import { LearningResourcesService } from 'src/app/shared/services/learning-resources.service';
import { newPostForm } from './new-post.config';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css'],
})
export class NewPostComponent implements OnInit {
  @Input() learningResourceId: number;
  @Output() addPost = new EventEmitter<Post>();

  newPostForm: FormGroup;
  validationErrors: string[] = [];
  formConfig: FormConfig;

  constructor(
    private fb: FormBuilder,
    private learningResourceService: LearningResourcesService
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.formConfig = newPostForm;
    this.newPostForm = this.fb.group(
      FormFieldBuilder.buildCtlConfig(this.formConfig)
    );
  }

  submitNewPost(): void {
    const newPost: Post = {
      content: this.newPostForm.value.content,
      learningResourceId: this.learningResourceId
    };
    this.learningResourceService.newResourcePost(newPost)?.subscribe((res) => {
      const addedPost: Post = res;
      this.addPost.emit(addedPost);
      this.newPostForm.setValue({ content: '' });
      this.newPostForm.markAsUntouched();
    });
  }
}
