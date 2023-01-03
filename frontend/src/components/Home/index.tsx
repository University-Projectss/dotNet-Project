import {
  Box,
  Card,
  Flex,
  Heading,
  Spinner,
  Text,
  VStack,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router";
import { useCustomToast } from "../Common/useCustomToast";
import { apiClient, authorise } from "../Utils/apiClient";
import { CarInterface } from "./types";

export const Home = () => {
  const navigate = useNavigate();
  const toast = useCustomToast();
  const [cars, setCars] = useState<CarInterface[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    apiClient
      .get("api/cars/all", authorise())
      .then((res) => {
        //console.log(res.data);
        setLoading(false);
        setCars(
          res.data.map((car: any) => {
            return {
              id: car.id,
              model: car.model,
              brand: car.brand,
            };
          })
        );
      })
      .catch((err) => {
        console.log(err);
        toast.createToast("Error get cars!", "error");
      });

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <VStack h="100%" p={10}>
      <Text margin={5} fontSize={30} fontFamily="serif" fontWeight="semibold">
        Welcom to Rent a Car!
      </Text>

      <Flex direction="column">
        <Text fontFamily="serif" fontSize={20}>
          Choose your car sir:
        </Text>
        <Flex wrap="wrap" marginTop={5} align="center" justify="center">
          {loading ? (
            <Spinner />
          ) : cars.length ? (
            cars.map((car) => {
              return (
                <Card
                  key={car.id}
                  minW="200px"
                  margin={5}
                  p={2}
                  cursor="pointer"
                  onClick={() => {
                    navigate(`/car/${car.brand}/${car.model}`);
                  }}
                >
                  <Box>
                    <Heading size="xs" textTransform="uppercase">
                      {car.brand}
                    </Heading>
                    <Text pt="2" fontSize="sm">
                      {car.model}
                    </Text>
                  </Box>
                </Card>
              );
            })
          ) : (
            <Text>There is no car for the moment.</Text>
          )}
        </Flex>
      </Flex>
    </VStack>
  );
};
