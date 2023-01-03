import { createContext } from "react";
import "./App.css";
import { RoutesComponent } from "./components/Routes";
import { UserContextInterface } from "./components/Utils/types";
import { useAuth } from "./components/Utils/useAuth";

export const UserContext = createContext<UserContextInterface>(
  {} as UserContextInterface
);

function App() {
  const createUser = useAuth();

  return (
    <UserContext.Provider value={createUser}>
      <RoutesComponent />
    </UserContext.Provider>
  );
}

export default App;
