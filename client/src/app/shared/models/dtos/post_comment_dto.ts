import { Post } from './post_dto';

export interface PostComment {
  commentId: string;
  content: string;
  postId: string;
  post: Post;
}
