import { useEffect, useState } from "react";
import { fetchFranchisees } from "../services/franchiseeService";
import { Franchisee } from "../types/franchisee";
import { useNavigate } from "react-router-dom";

export const FranchiseeList = () => {
  const [franchisees, setFranchisees] = useState<Franchisee[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchFranchisees().then(setFranchisees);
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Franchisee List</h1>
      <ul className="bg-white p-4 rounded shadow">
        {franchisees.map(f => (
          <li
            key={f.id}
            className="border-b py-2 hover:cursor-pointer hover:bg-gray-100"
            onClick={() => navigate(`/franchisee/${f.id}`)}
          >
            {f.name} — {f.region}
          </li>
        ))}
      </ul>
    </div>
  );
};
