export interface UserInterface {
  firstName: string;
  lastName: string;
  mail: string;
  id: string;
  roleName?: number;
}

export interface UserContextInterface {
  user: UserInterface;
  logOut: () => void;
  setUser: (val: UserInterface) => void;
}
