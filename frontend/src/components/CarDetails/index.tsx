import { Flex, Image, Spinner, Text, VStack } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { apiClient, authorise } from "../Utils/apiClient";

export const CarDetails = () => {
  const { brand } = useParams();
  const { model } = useParams();
  const [loading, setLoading] = useState<boolean>(true);
  const [link, setLink] = useState<string>("");

  useEffect(() => {
    apiClient
      .get(`api/cars/car-details/${brand}/${model}`, authorise())
      .then((res) => {
        console.log(res.data);
        setLink(res.data);
        setLoading(false);
      })
      .catch((err) => {
        console.log(err);
      });

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <VStack h="100%" p={10}>
      <Text margin={5} fontSize={30} fontFamily="serif" fontWeight="semibold">
        {brand + " " + model}
      </Text>
      {loading ? (
        <Flex width="100%" height="100%" align="center" justify="center">
          <Spinner />
        </Flex>
      ) : (
        // <iframe src={link} height="100%" width="100%" title="details"></iframe>
        <Image src={link} width="50vw" />
      )}
    </VStack>
  );
};
