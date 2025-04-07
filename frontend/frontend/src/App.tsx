import { BrowserRouter, Routes, Route } from "react-router-dom";
import { FranchiseeList } from "./pages/FranchiseeList";
import { KpiDetails } from "./pages/KpiDetails";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<FranchiseeList />} />
        <Route path="/franchisee/:id" element={<KpiDetails />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
