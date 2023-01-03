import {
  Box,
  Button,
  Flex,
  HStack,
  InputGroup,
  InputRightElement,
  Spacer,
  Spinner,
  Text,
  VStack,
} from "@chakra-ui/react";
import { useContext, useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "../../App";
import { RCInput } from "../Common/RCInput";
import { useCustomToast } from "../Common/useCustomToast";
import { apiClient } from "../Utils/apiClient";
import { requiredField } from "../Utils/inputValidators";
import { LoginInterface } from "./loginTypes";

export const Login = () => {
  const toast = useCustomToast();
  const navigate = useNavigate();
  const location = useLocation();
  const userContext = useContext(UserContext);

  const [userDetails, setUserDetails] = useState<LoginInterface>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
  });
  const [error, setError] = useState<LoginInterface>(userDetails);
  const [show, setShow] = useState<boolean>(false);
  const [signUp, setSignUp] = useState<boolean>(false);
  const [loading, setLoading] = useState<boolean>(false);
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
      setLoading(true);
      apiClient
        .post("api/users/create-client", {
          firstName: userDetails.firstName,
          lastName: userDetails.lastName,
          email: userDetails.email,
          password: userDetails.password,
        })
        .then((res) => {
          setLoading(false);
          //console.log(res.data);
          userContext.setUser({
            ...userContext.user,
            roleName: res.data.roleName,
          });
          toast.createToast(
            "Now please login into your new account!",
            "success"
          );
          setSignUp(false);
        })
        .catch((err) => {
          setLoading(false);
          console.log(err);
          toast.createToast("Something went wrong sir!", "error");
        });
    } else {
      //login, aka register
      setLoading(true);
      apiClient
        .post("api/authenticate/register", {
          firstName: "whatever",
          lastName: "whatever",
          email: userDetails.email,
          password: userDetails.password,
        })
        .then((res) => {
          setLoading(false);
          //console.log(res.data);
          userContext.setUser({
            ...userContext.user,
            ...res.data,
          });
          localStorage.setItem("token", res.data.token);
          toast.createToast("Login succesfully!", "success");
          if (location.pathname === "/login") navigate("/");
        })
        .catch((err) => {
          setLoading(false);
          console.log(err);
          toast.createToast("Incorect email or password!", "error");
        });
    }
  };

  useEffect(() => {
    if (localStorage.getItem("token")) {
      navigate("/");
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

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
        {loading ? (
          <Spinner />
        ) : (
          <Button marginBottom={2} onClick={handleLoginClick}>
            {signUp ? "Sign Up" : "Login"}
          </Button>
        )}

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
