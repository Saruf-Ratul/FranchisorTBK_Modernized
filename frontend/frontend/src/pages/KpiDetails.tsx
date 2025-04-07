import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { fetchFranchiseeKpis } from "../services/franchiseeService";
import { KpiResult } from "../types/franchisee";
import { KpiCard } from "../components/KpiCard";

export const KpiDetails = () => {
  const { id } = useParams();
  const [kpis, setKpis] = useState<KpiResult[]>([]);

  useEffect(() => {
    if (id) fetchFranchiseeKpis(id).then(setKpis);
  }, [id]);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">KPI Results</h1>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        {kpis.map(kpi => <KpiCard key={kpi.id} kpi={kpi} />)}
      </div>
    </div>
  );
};
