import { Box, Input, InputProps, Text } from "@chakra-ui/react";
import React from "react";

interface RCInputProps extends InputProps {
  value?: string;
  error?: string;
  label: string;
}

export const RCInput: React.FC<RCInputProps> = ({
  value,
  error,
  label,
  ...others
}) => {
  return (
    <Box w="100%">
      <Text textAlign="left">{label}</Text>
      <Input
        value={value}
        borderRadius={4}
        borderColor={error ? "red" : "black"}
        focusBorderColor={error ? "red" : "blue"}
        _placeholder={{ weight: "400", color: "gray.400" }}
        padding={6}
        margin={0}
        {...others}
      />
      <Box h={2} w="100%">
        {error && <Text color={"red"}>{error}</Text>}
      </Box>
    </Box>
  );
};
