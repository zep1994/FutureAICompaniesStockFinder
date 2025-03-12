import { useParams } from "react-router-dom";

const ToolDetail = () => {
  const { id } = useParams();

  return (
    <div className="tool-detail">
      <h1>Tool Details</h1>
      <p>Showing details for tool ID: {id}</p>
    </div>
  );
};

export default ToolDetail;
    