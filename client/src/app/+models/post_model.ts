import { PostComment } from './dtos/post_comment_dto';
import { Post } from './dtos/post_dto';

export interface PostModel extends Post {
    comments: PostComment[];
}