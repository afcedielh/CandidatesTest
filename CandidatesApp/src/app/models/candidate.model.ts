import { ExperienceModel } from "./experience.model";

export class CandidateModel{
  idCandidate!: number;
  name!: string;
  surname!: string;
  birthdate!: Date;
  email!: string;
  experiences: ExperienceModel[] = [];
}
