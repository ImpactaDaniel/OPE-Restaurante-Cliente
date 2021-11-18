export interface APIResponse<T> {
  response: T;
  success: boolean;
  notifications: Notification[];
}

export interface Notification {
  code: number;
  message: string;
}
