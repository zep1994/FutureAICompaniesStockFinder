import { Link } from "react-router-dom";

const ToolCard = ({ tool }) => {
  return (
    <div className="tool-card">
      <h3>{tool.name}</h3>
      <p>{tool.description}</p>
      <Link to={`/tool/${tool.id}`} className="details-link">View Details →</Link>
    </div>
  );
};

export default ToolCard;
