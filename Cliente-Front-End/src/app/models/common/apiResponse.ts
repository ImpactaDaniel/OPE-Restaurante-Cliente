export interface APIResponse<T> {
  entidade: T;
  sucesso: boolean;
  erros: string[];
}

