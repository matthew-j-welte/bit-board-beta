import { Post } from './post_dto';

export interface PostComment {
  commentId: number;
  content: string;
  postId: number;
  post: Post;
}
