import {defineConfig} from "vite";
import react from "@vitejs/plugin-react";

import cssInjectedByJsPlugin from "vite-plugin-css-injected-by-js";

export default defineConfig({
  plugins: [cssInjectedByJsPlugin(), react()],
  build: {
    manifest: true,
    rollupOptions: {
      output: {
        dir: "../wwwroot/react-app", // Output to the wwwroot folder of .NET project
      },
    },
  },
});
