import { KpiResult } from "../types/franchisee";

interface Props {
  kpi: KpiResult;
}

export const KpiCard = ({ kpi }: Props) => (
  <div className="p-4 border rounded bg-white shadow">
    <h3 className="text-lg font-semibold">{new Date(kpi.date).toLocaleDateString()}</h3>
    <p>Revenue: ${kpi.revenue}</p>
    <p>Expenses: ${kpi.expenses}</p>
    <p className="font-bold text-green-600">Profit: ${kpi.profit}</p>
  </div>
);
