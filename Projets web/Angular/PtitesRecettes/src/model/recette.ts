import { Categorie } from './categorie';

export class Recette {
  id: string;
  nom: string;
  description: string;
  contientGluten: boolean;
  categorie: Categorie;
  prix: string;
  imageUrl: string;


}
