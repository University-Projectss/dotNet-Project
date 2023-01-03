import { useToast } from "@chakra-ui/react";

export const useCustomToast = () => {
  const toast = useToast();

  const createToast = (description: string, status: "success" | "error") =>
    toast({
      title: status[0].toUpperCase() + status.substring(1),
      description: description,
      status: status,
      duration: 3000,
    });

  return { createToast };
};
