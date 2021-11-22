export interface APIResponse<T> {
  response: T;
  sucesso: boolean;
  erros: string[];
}

