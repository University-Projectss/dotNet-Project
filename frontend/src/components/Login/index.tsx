import {
  Box,
  Button,
  Flex,
  HStack,
  InputGroup,
  InputRightElement,
  Spacer,
  Text,
  VStack,
} from "@chakra-ui/react";
import { useState } from "react";
import { RCInput } from "../Common/RCInput";
import { apiClient } from "../Utils/apiClient";
import { requiredField } from "../Utils/inputValidators";
import { LoginInterface } from "./loginTypes";

export const Login = () => {
  const [userDetails, setUserDetails] = useState<LoginInterface>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
  });
  const [error, setError] = useState<LoginInterface>(userDetails);

  const [show, setShow] = useState<boolean>(false);
  const [signUp, setSignUp] = useState<boolean>(false);
  const changePasswordVisibility = () => setShow(!show);
  const handleSignUpClick = () => setSignUp(true);

  const handleInputOnChange = (key: string, val: string) => {
    setUserDetails({ ...userDetails, [key]: val });
    setError({
      ...error,
      [key]: requiredField(val),
    });
  };

  const handleLoginClick = () => {
    if (
      userDetails.email === "" ||
      userDetails.password === "" ||
      (signUp && (userDetails.firstName === "" || userDetails.lastName === ""))
    ) {
      setError({
        firstName: requiredField(userDetails.firstName),
        lastName: requiredField(userDetails.lastName),
        email: requiredField(userDetails.email),
        password: requiredField(userDetails.password),
      });
    } else if (signUp) {
      //create customer
    } else {
      //login, aka register
      apiClient
        .post("api/authenticate/register", {
          firstName: "",
          lastName: "",
          email: userDetails.email,
          password: userDetails.password,
        })
        .then((res) => {
          console.log(res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    }
  };

  return (
    <Flex
      direction="column"
      w="100vw"
      height="100vh"
      align="center"
      justify="center"
    >
      <VStack textAlign="left">
        {signUp && (
          <HStack>
            <RCInput
              value={userDetails.firstName}
              label="First Name"
              placeholder="Robert"
              onChange={(e) => {
                handleInputOnChange("firstName", e.target.value);
              }}
              error={error.firstName}
            />
            <Spacer />
            <RCInput
              value={userDetails.lastName}
              label="Last Name"
              placeholder="Udrea"
              onChange={(e) => {
                handleInputOnChange("lastName", e.target.value);
              }}
              error={error.lastName}
            />
          </HStack>
        )}
        <HStack>
          <RCInput
            value={userDetails.email}
            label="Email"
            placeholder="robert@email.com"
            onChange={(e) => {
              handleInputOnChange("email", e.target.value);
            }}
            error={error.email}
          />
          <Spacer />
          <InputGroup size="md">
            <RCInput
              value={userDetails.password}
              pr="4.5rem"
              type={show ? "text" : "password"}
              placeholder="Enter password"
              label="Password"
              error={error.password}
              onChange={(e) => {
                handleInputOnChange("password", e.target.value);
              }}
            />
            <InputRightElement width="4.5rem">
              <Button
                h="1.75rem"
                marginBottom={-14}
                size="sm"
                onClick={changePasswordVisibility}
              >
                {show ? "Hide" : "Show"}
              </Button>
            </InputRightElement>
          </InputGroup>
        </HStack>
      </VStack>
      <Box position="absolute" bottom="20vh" textAlign="center">
        <Button marginBottom={2} onClick={handleLoginClick}>
          {signUp ? "Sign Up" : "Login"}
        </Button>

        {!signUp && (
          <Flex>
            <Text marginRight={2}>Don't have an account?</Text>

            <Text
              cursor="pointer"
              textDecoration="underline"
              onClick={handleSignUpClick}
            >
              Sign up!
            </Text>
          </Flex>
        )}
      </Box>
    </Flex>
  );
};
