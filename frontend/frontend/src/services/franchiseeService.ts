import { Franchisee, KpiResult } from "../types/franchisee";

// const API_BASE = "https://localhost:44334/api";
const API_BASE = "https://localhost:44334/api"; // match https port in launchSettings



export const fetchFranchisees = async (): Promise<Franchisee[]> => {
  const res = await fetch(`${API_BASE}/franchisees`);
  return await res.json();
};

export const fetchFranchiseeKpis = async (id: string): Promise<KpiResult[]> => {
  const res = await fetch(`${API_BASE}/franchisees/${id}/kpis`);
  return await res.json();
};
