import React, { createContext, useState } from 'react';
import { User } from 'src/types/user.type';

interface UserContextType {
  user: User | null;
  setUser: (user: User | null) => void;
}

export const UserContext = createContext<UserContextType>({
  user: null,
  setUser: (user) => console.log(user),
});

export type UserProviderProps = {
  children: React.ReactElement;
}
export const UserProvider: React.FC<UserProviderProps> = ({ children }: UserProviderProps) => {
  const [user, setUser] = useState<User| null>(null);

  React.useEffect(() => {
    const didMount = async () => {
      if(!user) {
        const fromStorage = JSON.parse(localStorage.getItem('user')!) as User;
        if(!fromStorage) {
          if(!window.location.pathname.includes('/login')) {
            window.location.href = '/login';
          }
        } else {
          setUser(fromStorage);
        }
      }
    };
    didMount();
  }, [user]);

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};