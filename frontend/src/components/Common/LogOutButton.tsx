import { Button } from "@chakra-ui/react";
import React, { useContext } from "react";
import { UserContext } from "../../App";

export const LogOutButton = () => {
  const userContext = useContext(UserContext);

  return (
    <Button position="absolute" top={5} right={8} onClick={userContext.logOut}>
      Log out
    </Button>
  );
};
