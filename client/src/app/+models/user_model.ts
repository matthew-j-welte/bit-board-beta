import { CodeEditorConfiguration } from './dtos/code_editor_configuration_dto';
import { LearningResource } from './dtos/learning_resource_dto';
import { PostComment } from './dtos/post_comment_dto';
import { Post } from './dtos/post_dto';
import { User } from './dtos/user_dto';
import { UserSkill } from './dtos/user_skill_dto';

export interface UserModel extends User {
    userSkills: UserSkill[];
    learningResources: LearningResource[];
    codeEditorConfigurations: CodeEditorConfiguration[];
    posts: Post[];
    comments: PostComment[];
}
