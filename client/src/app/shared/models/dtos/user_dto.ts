export interface User extends UserInfo {
  userId: string;
}

export interface UserInfo {
  userName: string;
  firstName: string;
  lastName: string;
  imageUrl: string;
  yearsExperience: number;
  title: string;
  technicalSummary: string;
  currentEmployer: string;
  yearsAtEmployer: number;
  jobDescription: string;
}
